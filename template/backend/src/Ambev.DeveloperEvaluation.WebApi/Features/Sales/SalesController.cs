using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSaleProduct;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sale operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController(IMediator _mediator, IMapper _mapper) : BaseController
{
    //private readonly ILogger<SalesController> _logger;

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

        return Created(string.Empty, ApiResponseWithData<CreateSaleResponse>.Result("", response));
    }

    /// <summary>
    /// Updates a new sale
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

        return Ok(ApiResponseWithData<UpdateSaleResponse>.Result("Sale Updated successfully", response));
    }

    /// <summary>
    /// Updates a new sale
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
        var command = _mapper.Map<GetSaleCommand>(id);

        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<GetSaleResponse>(result);

        return Ok(ApiResponseWithData<GetSaleResponse>.Result("Sale get successfully", response));
    }

    /// <summary>
    /// Updates a new sale
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Updated sale details</returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CancelSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CancelSaleCommand>(id);

        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<CancelSaleResponse>(result);

        return Ok(ApiResponseWithData<CancelSaleResponse>.Result("Sale Cancel successfully", response));
    }

    /// <summary>
    /// Creates a new sale
    /// </summary>
    /// <param name="request">The sale product creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale product details</returns>
    [HttpPost]
    [Route("{id}/products")]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSaleProduct([FromRoute] Guid id, [FromBody] CreateSaleProductRequest request, CancellationToken cancellationToken)
    {
        
            var command = _mapper.Map<CreateSaleProductCommand>(request, opt => { opt.Items["SaleId"] = id; });
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleProductResponse>
            {
                Success = true,
                Message = "Sale products created successfully",
                Data = _mapper.Map<CreateSaleProductResponse>(response)
            });
    }
}
