import { Module } from '@nestjs/common';
import { CurrenciesModule } from './currencies.module';
import * as dotenv from 'dotenv';
import { ClientsModule, Transport } from '@nestjs/microservices';
import { join } from 'path';
import { CacheModule } from '@nestjs/cache-manager';
import { redisStore } from 'cache-manager-redis-yet';
import { PROTO_PATH } from 'src/api/grpc/grpc.constants';

dotenv.config();

@Module({
  imports: [
    //gRPC config:
    ClientsModule.register([
      {
        name: 'CURRENCIES_PACKAGE',
        transport: Transport.GRPC,
        options: {
          package: 'currencies',
          protoPath: join(__dirname, PROTO_PATH),
        },
      },
    ]),

    // Redis Cache config:
    CacheModule.registerAsync({
      isGlobal: true,
      useFactory: async () => ({
        store: await redisStore({
          socket: {
            host: process.env.REDIS_HOST,
            port: parseInt(process.env.REDIS_PORT!),
            tls: true,
          },
          password: process.env.REDIS_PASSWORD,
        }),
        // ttl: 10000,
      }),
    }),

    //App modules
    CurrenciesModule,
  ],
  controllers: [],
  providers: [],
})
export class AppModule {}
