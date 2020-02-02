using DbEntities;
using ShopApiTestTask.Models;
using ShopApiTestTask.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ShopApiTestTask.Controllers
{
	public class StoreController : ApiController
	{
		private readonly IStoreService _storeService = new StoreService();

		public StoreController()
		{
		}

		public StoreController(IStoreService storeService)
		{
			_storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
		}

		/// <summary>
		/// Add store
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("api/store/create")]
		public async Task<IHttpActionResult> AddStore([FromBody]StoreViewModel store)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid data.");

			if (await _storeService.StoreExists(store))
			{
				var original = await _storeService.GetStore(store);
				return new NegotiatedContentResult<Store>(HttpStatusCode.Conflict, original, this);
			}

			//make descr optional
			var newStore = await _storeService.AddStore(store);

			if (newStore == null)
				return BadRequest("The item was not added.");

			//return type is db object or view?
			return Ok(newStore);
		}

		/// <summary>
		/// Edit store
		/// </summary>
		/// <returns></returns>
		[HttpPut]
		[Route("api/store/edit")]
		public async Task<IHttpActionResult> EditStore([FromBody]StoreViewModel store)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid data.");

			if (!await _storeService.StoreExists(store))
			{
				return NotFound();
			}

			var newStore = await _storeService.EditStore(store);

			return Ok(newStore);
		}
	}
}