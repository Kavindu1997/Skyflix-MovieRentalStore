using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyFlix.Data;
using SkyFlix.Dto;
using SkyFlix.Models;


namespace SkyFlix.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CustomerDto> GetCustomers()
        {
            var customerDtos = _context.Customers.Include(c => c.MembershipType)
                                     .ToList()
                                     .Select(_mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            var uri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}{HttpContext.Request.Path}{customerDto.Id}";

            return Created(new Uri(uri), customerDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}