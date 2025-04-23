import { Module } from '@nestjs/common';
import ICurrenciesClient from 'src/application/clients/icurrencies.client';
import CurrenciesClient from '../clients/currencies.client';
import * as dotenv from 'dotenv';
import CurrenciesController from 'src/api/controllers/currencies.controller';
import ICurrenciesService from 'src/application/services/contracts/icurrencies.service';
import CurrenciesService from 'src/application/services/implementations/currencies.service';
import { CacheManager } from 'src/application/symbols/dependency-injection.symbols';
import { CACHE_MANAGER as cacheManager } from '@nestjs/cache-manager';

dotenv.config();

@Module({
  imports: [],
  controllers: [CurrenciesController],
  providers: [
    // HTTP Clients:
    {
      provide: ICurrenciesClient,
      useClass: CurrenciesClient,
    },

    // Services:
    {
      provide: ICurrenciesService,
      useClass: CurrenciesService,
    },

    // CacheManager:
    {
      provide: CacheManager,
      useExisting: cacheManager,
    },
  ],
})
export class CurrenciesModule {}
