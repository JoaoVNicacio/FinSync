import { Inject } from '@nestjs/common';
import ICurrenciesService from '../contracts/icurrencies.service';
import ICurrenciesClient from 'src/application/clients/icurrencies.client';
import { DEFAULT_CURRENCY } from 'src/domain/constants/currencies.constants';
import { CacheManager } from 'src/application/symbols/dependency-injection.symbols';
import { Cache } from 'cache-manager';
import TimeParser from 'src/core/utils/time.parser';

class CurrenciesService implements ICurrenciesService {
  constructor(
    @Inject(ICurrenciesClient)
    private readonly _currencyClient: ICurrenciesClient,

    @Inject(CacheManager)
    private readonly _cacheManager: Cache,
  ) {}

  async getCurenciesAndConversions(
    baseCurrency: string = DEFAULT_CURRENCY,
  ): Promise<Record<string, number> | null | undefined> {
    baseCurrency = baseCurrency.toLowerCase();
    const cachingKey = `curencies-and-conversions/${baseCurrency}`;
    const cachedToken =
      await this._cacheManager.get<Record<string, number>>(cachingKey);

    if (cachedToken) return cachedToken;

    const curenciesAndConversionsResponse =
      await this._currencyClient.getCurencies(baseCurrency);

    await this._cacheManager.set(
      cachingKey,
      curenciesAndConversionsResponse,
      TimeParser.getInterval(new Date(), TimeParser.getTomorrowDate),
    );

    return curenciesAndConversionsResponse;
  }

  async getAvailableCurrenciesAcronyms(): Promise<Array<string>> {
    const CACHING_KEY = 'currencies-acronyms';

    const cachedResults =
      await this._cacheManager.get<Array<string>>(CACHING_KEY);

    if (cachedResults) return cachedResults;

    const result = Object.keys(
      (await this.getCurenciesAndConversions()) as object,
    );

    await this._cacheManager.set(
      CACHING_KEY,
      result,
      TimeParser.getInterval(new Date(), TimeParser.getTomorrowDate),
    );

    return result;
  }
}

export default CurrenciesService;
