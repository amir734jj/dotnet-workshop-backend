using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Abstracts
{
    public abstract class AbstractBasicCrudController<T> : Controller
    {
        [NonAction]
        protected abstract IBasicCrudLogic<T> BasicCrudLogic();

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<>), 200)]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await BasicCrudLogic().GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(await BasicCrudLogic().Get(id));
        }

        [HttpPut]
        [Route("{id}")]
        public virtual async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] T instance)
        {
            return Ok(await BasicCrudLogic().Update(id, instance));
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return Ok(await BasicCrudLogic().Delete(id));
        }
        
        [HttpPost]
        [Route("")]
        public virtual async Task<IActionResult> Save([FromBody] T instance)
        {
            return Ok(await BasicCrudLogic().Save(instance));
        }
    }
}