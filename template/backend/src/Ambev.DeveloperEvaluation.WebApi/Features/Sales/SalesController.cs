using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSaleProduct;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Commons.Responses;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sale operations
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class SalesController(IMediator _mediator, IMapper _mapper) : BaseController
{
    /// <summary>
    /// Creates a new sale
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateSaleCommand>(request);
        
        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<CreateSaleResponse>(result);

        return Created(string.Empty, ApiResponseWithData<CreateSaleResponse>.Result("Sale created successfully", response));
    }

    /// <summary>
    /// Updates a sale
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated sale details</returns>
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSale([FromRoute] Guid id, [FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateSaleCommand>(request, opt => { opt.Items["Id"] = id; });

        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<UpdateSaleResponse>(result);

        return Ok(response);
    }

    /// <summary>
    /// Get sale
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated sale details</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetSaleQuery>(id);

        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<GetSaleResponse>(result);

        return Ok(response);
    }

    /// <summary>
    /// Get sales
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated sale details</returns>
    [HttpGet]    
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSales([FromQuery] int page = 1, int size = 10, string order = "", CancellationToken cancellationToken = default)
    {
        var request = GetSalesRequest.Builder(page, size, order);

        var command = _mapper.Map<GetSalesQuery>(request);

        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<GetSalesResponse>(result);

        return OkPaginated(new PaginatedList<SaleResponse>(response.Sales, response.TotalCount, page, size));
    }

    /// <summary>
    /// Cancel sale
    /// </summary>
    /// <param name="id">The id request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated sale details</returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CancelSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CancelSaleCommand>(id);

        await _mediator.Send(command, cancellationToken);

        return Ok(new { id, Message = "Sale cancel successfully!" });
    }

    /// <summary>
    /// Cancel sale product
    /// </summary>
    /// <param name="id">The sale id request</param>
    /// <param name="productId">The product id request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated sale details</returns>
    [HttpDelete]
    [Route("{id}/products/{productId}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CancelProductSale([FromRoute] Guid id, Guid productId, CancellationToken cancellationToken)
    {
        var request = CancelSaleProductRequest.Builder(id, productId);
        
        var command = _mapper.Map<CancelSaleProductCommand>(request);

        await _mediator.Send(command, cancellationToken);

        return Ok(new { id, productId, Message = "Sale product cancel successfully" });
    }    
}
