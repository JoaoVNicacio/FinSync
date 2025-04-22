//import { Metadata, ServerUnaryCall } from '@grpc/grpc-js';
import { Controller, Inject } from '@nestjs/common';
import { GrpcMethod } from '@nestjs/microservices';
import ICurrenciesService from 'src/application/services/contracts/icurrencies.service';
import { DEFAULT_CURRENCY } from 'src/domain/constants/currencies.constants';
import {
  BaseCurrencyRequest,
  CurrencyConversionsResponse,
} from 'src/proto/output/currencies';
import {
  AVAILABLE_CURRENCIES_ENDPOINT,
  CURRENCIES_AND_CONVERSIONS_ENDPOINT,
  GRPC_CURRENCIES_SERVICE,
} from '../grpc/grpc.constants';

@Controller()
class CurrenciesController {
  constructor(
    @Inject(ICurrenciesService)
    private readonly _currenciesService: ICurrenciesService,
  ) {}

  @GrpcMethod(GRPC_CURRENCIES_SERVICE, CURRENCIES_AND_CONVERSIONS_ENDPOINT)
  async getCurenciesAndConversions(
    data: BaseCurrencyRequest,
  ): Promise<CurrencyConversionsResponse> {
    return {
      conversions:
        (await this._currenciesService.getCurenciesAndConversions(
          data.baseCurrency ?? DEFAULT_CURRENCY,
        )) ?? undefined,
    };
  }

  @GrpcMethod(GRPC_CURRENCIES_SERVICE, AVAILABLE_CURRENCIES_ENDPOINT)
  async GetAvailableCurrenciesAcronyms(): Promise<{ acronyms: Array<string> }> {
    return {
      acronyms: await this._currenciesService.getAvailableCurrenciesAcronyms(),
    };
  }
}

export default CurrenciesController;
