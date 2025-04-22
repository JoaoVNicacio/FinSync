import { NestFactory } from '@nestjs/core';
import { join } from 'path';
import { AppModule } from './infra/modules/app.module';
import { MicroserviceOptions, Transport } from '@nestjs/microservices';
import * as dontenv from 'dotenv';

dontenv.config();

async function bootstrap() {
  const app = await NestFactory.createMicroservice<MicroserviceOptions>(
    AppModule,
    {
      transport: Transport.GRPC,
      options: {
        package: 'currencies',
        protoPath: join(__dirname, './proto/currencies.proto'),
        url: `0.0.0.0:${process.env.PORT ?? 3000}`,
      },
    },
  );

  await app.listen();
}

void bootstrap();
