import { Module } from '@nestjs/common';
import { CurrenciesModule } from './currencies.module';
import * as dotenv from 'dotenv';

dotenv.config();

@Module({
  imports: [CurrenciesModule],
  controllers: [],
  providers: [],
})
export class AppModule {}
