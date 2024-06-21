using Admin.Api.Entities;
using Grpc.Net.Client;
using GRPCService.Protos;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOfferController : ControllerBase
    {
        private readonly GrpcChannel _channel;
        private readonly ProductOfferService.ProductOfferServiceClient _client;
        private readonly IConfiguration _configuration;

        public ProductOfferController(IConfiguration configuration)
        {
            _configuration = configuration;
            _channel =
                GrpcChannel.ForAddress(_configuration.GetValue<string>("GrpcSettings:OfferServiceUrl"));
            _client = new ProductOfferService.ProductOfferServiceClient(_channel);
        }

        [HttpGet]
        public async Task<Offers> GetOfferListAsync()
        {
            try
            {
                var response = await _client.GetOfferListAsync(new Empty { });

                return response;
            }
            catch
            {

            }
            return null;
        }

        [HttpGet("{id}")]
        public async Task<OfferDetail> GetOfferByIdAsync([FromRoute] int id)
        {
            try
            {
                var request = new GetOfferDetailRequest
                {
                    ProductId = id
                };

                var response = await _client.GetOfferAsync(request);

                return response;
            }
            catch
            {

            }
            return null;
        }

        [HttpPost]
        public async Task<OfferDetail> AddOfferAsync(Offer offer)
        {
            try
            {
                var offerDetail = new OfferDetail
                {
                    Id = offer.Id,
                    ProductName = offer.ProductName,
                    OfferDescription = offer.OfferDescription
                };

                var response = await _client.CreateOfferAsync(new CreateOfferDetailRequest()
                {
                    Offer = offerDetail
                });

                return response;
            }
            catch
            {

            }
            return null;
        }

        [HttpPut]
        public async Task<OfferDetail> UpdateOfferAsync(Offer offer)
        {
            try
            {
                var offerDetail = new OfferDetail
                {
                    Id = offer.Id,
                    ProductName = offer.ProductName,
                    OfferDescription = offer.OfferDescription
                };

                var response = await _client.UpdateOfferAsync(new UpdateOfferDetailRequest()
                {
                    Offer = offerDetail
                });

                return response;
            }
            catch
            {

            }
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<DeleteOfferDetailResponse> DeleteOfferAsync([FromRoute] int id)
        {
            try
            {
                var response = await _client.DeleteOfferAsync(new DeleteOfferDetailRequest()
                {
                    ProductId = id
                });
                return response;
            }
            catch
            {

            }
            return null;
        }
    }
}
