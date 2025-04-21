import { Inject } from '@nestjs/common';
import ICurrenciesService from '../contracts/icurrencies.service';
import ICurrenciesClient from 'src/application/clients/icurrencies.client';
import { DEFAULT_CURRENCY } from 'src/domain/constants/currencies.constants';

class CurrenciesService implements ICurrenciesService {
  constructor(
    @Inject(ICurrenciesClient)
    private readonly _currencyClient: ICurrenciesClient,
  ) {}

  async getCurenciesAndConversions(
    baseCurrency: string = DEFAULT_CURRENCY,
  ): Promise<Record<string, bigint> | null | undefined> {
    baseCurrency = baseCurrency.toLowerCase();

    return await this._currencyClient.getCurencies(baseCurrency);
  }

  async getAvailableCurrenciesAcronyms(): Promise<Array<string>> {
    return Object.keys((await this.getCurenciesAndConversions()) as object);
  }
}

export default CurrenciesService;
