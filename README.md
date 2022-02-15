# AJKafka
Playing around with Apache Kafka using .NET and Docker

## Prerequisites

-> Must have Docker installed (https://www.docker.com/products/docker-desktop)

## Basic steps to config the local Kafka cluster

- Pull Zookeeper image
docker pull confluentinc/cp-zookeeper

- Pull Kafka image
docker pull confluentinc/cp-kafka

- Create a network for Kafka and Zookeeper
docker network create kafka

- Configure and run Zookeeper
docker run -d --network=kafka --name=zookeeper -e ZOOKEEPER_CLIENT_PORT=2181 -e ZOOKEEPER_TICK_TIME=2000 -p 2181:2181 confluentinc/cp-zookeeper

docker logs zookeeper

- Configure and run Kafka
docker run -d --network=kafka --name=kafka -p 9092:9092 -e KAFKA_ZOOKEEPER_CONNECT=zookeeper:2181 -e KAFKA_ADVERTISED_LISTENERS=PLAINTEXT://localhost:9092 -e KAFKA_OFFSETS_TOPIC_REPLICATION_FACTOR=1 confluentinc/cp-kafka

docker logs kafka

## NuGet Package for KAFKA

-> Official Confluent package
https://www.nuget.org/packages/Confluent.Kafka/

Docs: https://github.com/confluentinc/confluent-kafka-dotnet/

Install-Package Confluent.Kafka -Version 1.8.2
dotnet add package Confluent.Kafka --version 1.8.2
<PackageReference Include="Confluent.Kafka" Version="1.8.2" />

-> Alternative package

https://www.nuget.org/packages/kafka-sharp/

## Additional resources

-> CONDUKTOR 
https://www.conduktor.io/
https://www.conduktor.io/download

In the simplest terms, Conduktor is a full-featured native desktop application that plugs directly into Apache Kafka 
to bring visibility to the management of Kafka clusters, applications, and microservices.

--> Used CONDUKTOR to connect to my local Kafka cluster and create a Topic named "demoAJ"





















