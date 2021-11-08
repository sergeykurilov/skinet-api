using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Inferfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrands;
        private readonly IGenericRepository<ProductType> _productsType;
        private readonly IMapper _mapper;

        public ProductsController(
                IGenericRepository<Product> productsRepo,
                IGenericRepository<ProductBrand> productBrands,
                IGenericRepository<ProductType> productsType,
                IMapper mapper
                )
        {
            _productsRepo = productsRepo;
            _productBrands = productBrands;
            _productsType = productsType;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>>  GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsync(spec);
            return Ok(
                _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }
   
        [HttpGet("{id}")] 
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
        {
            return Ok(await _productBrands.ListAllAsync());
        }
        
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypes()
        {
            return Ok(await _productsType.ListAllAsync());
        }
    }
}