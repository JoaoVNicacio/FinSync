import { Module } from '@nestjs/common';
import ICurrenciesClient from 'src/application/clients/icurrencies.client';
import CurrenciesClient from '../clients/currencies.client';
import * as dotenv from 'dotenv';
import CurrenciesController from 'src/api/controllers/currencies.controller';
import ICurrenciesService from 'src/application/services/contracts/icurrencies.service';
import CurrenciesService from 'src/application/services/implementations/currencies.service';

dotenv.config();

@Module({
  imports: [],
  controllers: [CurrenciesController],
  providers: [
    {
      provide: ICurrenciesClient,
      useClass: CurrenciesClient,
    },
    {
      provide: ICurrenciesService,
      useClass: CurrenciesService,
    },
  ],
})
export class CurrenciesModule {}
