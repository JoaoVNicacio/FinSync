import { Module } from '@nestjs/common';
import ICurrenciesClient from 'src/application/clients/icurrencies.client';
import CurrenciesClient from '../clients/currencies.client';
import * as dotenv from 'dotenv';

dotenv.config();

@Module({
  imports: [],
  controllers: [],
  providers: [
    {
      provide: ICurrenciesClient,
      useClass: CurrenciesClient,
    },
  ],
})
export class CurrenciesModule {}
