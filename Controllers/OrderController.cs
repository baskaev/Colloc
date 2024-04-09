using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
            if (_repository.GetAllOrders().Count() == 0)
                _repository.AddOrder(new Order());
        }

        public IActionResult Index()
        {
            return View(_repository.GetAllOrders());
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _repository.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }


        public IActionResult Edit(int id)
        {
            var order = _repository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }


        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(/*int id,*/ Order order)
        {
            //if (id != order.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                _repository.EditOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // Методы для Details и Delete можно добавить по аналогии с Create и Edit, если они нужны.


        // GET: Order/ByType
        public IActionResult ByType(string orderType)
        {
            var orders = _repository.GetAllOrders().Where(o => o.OrderType == orderType);
            return View(orders);
        }

    }
}
