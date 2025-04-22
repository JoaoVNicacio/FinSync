import { Module } from '@nestjs/common';
import { CurrenciesModule } from './currencies.module';
import * as dotenv from 'dotenv';
import { ClientsModule, Transport } from '@nestjs/microservices';
import { join } from 'path';

dotenv.config();

@Module({
  imports: [
    //gRPC config
    ClientsModule.register([
      {
        name: 'CURRENCIES_PACKAGE',
        transport: Transport.GRPC,
        options: {
          package: 'currencies',
          protoPath: join(__dirname, '../../proto/currencies.proto'),
        },
      },
    ]),

    //App modules
    CurrenciesModule,
  ],
  controllers: [],
  providers: [],
})
export class AppModule {}
