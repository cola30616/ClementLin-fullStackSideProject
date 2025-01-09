﻿using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace sp_skishop.Controllers
{
    public class CartController(ICartService cartService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
        {
            var cart = await cartService.GetCartAsync(id);
            return Ok(cart ?? new ShoppingCart { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
        {
            var updatedCart = await cartService.SetCartAsync(cart);

            if (updatedCart == null) return BadRequest("Problem With Cart");

            return updatedCart;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCart(string id)
        {
            var result = await cartService.DeleteCartAsync(id);

            if (!result) return BadRequest("Problem Deleting Cart");

            return Ok();
        }
    }
}
