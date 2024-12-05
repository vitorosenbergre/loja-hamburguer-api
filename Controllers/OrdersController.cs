using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEFProject.Data;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _contextOrders;

    public OrdersController(AppDbContext context)
    {
        _contextOrders = context;
    }

    // GET: api/Orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await _contextOrders.Orders
            .Include(o => o.OrderProducts)    // Inclui os produtos do pedido
            .ThenInclude(op => op.Product)    // Inclui o produto associado a cada OrderProduct
            .Include(o => o.UserOrders)      // Inclui os usuários do pedido
            .ThenInclude(uo => uo.User)     // Inclui o usuário associado a cada UserOrder
            .Select(o => new
            {
                o.Id,
                o.StatusId,
                o.Value,
                OrderProducts = o.OrderProducts.Select(op => new
                {
                    op.OrderId,
                    op.ProductId
                }).ToList(),
                UserOrders = o.UserOrders.Select(uo => new
                {
                    uo.UserId,
                    uo.OrderId
                }).ToList()
            })
            .ToListAsync();

        // Retorna os resultados de forma que o cliente receba apenas os IDs
        return Ok(orders);
    }

    // GET: api/Orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _contextOrders.Orders
            .Include(o => o.OrderProducts)  // Incluir produtos no pedido
            .Include(o => o.UserOrders)     // Incluir usuários no pedido
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
        // Verifica se o status existe
        var status = await _contextOrders.Status.FindAsync(order.StatusId);
        if (status == null)
        {
            return BadRequest("Status não encontrado.");
        }

        // Cria o novo pedido (sem produtos ou usuários inicialmente)
        var newOrder = new Order
        {
            StatusId = order.StatusId,
            Value = order.Value,  // Preenche o valor total do pedido
        };

        // Adiciona os produtos ao pedido, associando o pedido aos produtos
        if (order.OrderProducts != null)
        {
            foreach (var orderProduct in order.OrderProducts)
            {
                var product = await _contextOrders.Products.FindAsync(orderProduct.ProductId);
                if (product == null)
                {
                    return BadRequest($"Produto com ID {orderProduct.ProductId} não encontrado.");
                }

                // Associando explicitamente o pedido ao OrderProduct e o produto ao OrderProduct
                var orderProductEntity = new OrderProduct
                {
                    Order = newOrder,  // A associação explícita do pedido
                    Product = product  // A associação explícita do produto
                };
                newOrder.OrderProducts.Add(orderProductEntity);
            }
        }

        // Adiciona os usuários ao pedido, associando o pedido aos usuários
        if (order.UserOrders != null)
        {
            foreach (var userOrder in order.UserOrders)
            {
                var user = await _contextOrders.Users.FindAsync(userOrder.UserId);
                if (user == null)
                {
                    return BadRequest($"Usuário com ID {userOrder.UserId} não encontrado.");
                }

                // Associando explicitamente o pedido ao UserOrder e o usuário ao UserOrder
                var userOrderEntity = new UserOrder
                {
                    Order = newOrder,  // A associação explícita do pedido
                    User = user  // A associação explícita do usuário
                };
                newOrder.UserOrders.Add(userOrderEntity);
            }
        }

        // Adiciona o pedido à tabela de pedidos
        _contextOrders.Orders.Add(newOrder);

        // Salva as alterações no banco de dados
        await _contextOrders.SaveChangesAsync();

        return CreatedAtAction("GetOrder", new { id = newOrder.Id }, newOrder);
    }


    // PUT: api/Orders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        _contextOrders.Entry(order).State = EntityState.Modified;

        try
        {
            await _contextOrders.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _contextOrders.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        _contextOrders.Orders.Remove(order);
        await _contextOrders.SaveChangesAsync();

        return NoContent();
    }

    private bool OrderExists(int id)
    {
        return _contextOrders.Orders.Any(e => e.Id == id);
    }
}
