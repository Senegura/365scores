docker-compose exec broker /opt/kafka/bin/kafka-topics.sh -create --topic fruits --bootstrap-server broker:29092
docker-compose exec broker /opt/kafka/bin/kafka-topics.sh -create --topic soccer-scores --bootstrap-server broker:29092
docker-compose exec broker /opt/kafka/bin/kafka-topics.sh -create --topic football-scores --bootstrap-server broker:29092
docker-compose exec broker /opt/kafka/bin/kafka-topics.sh -create --topic basketball-scores --bootstrap-server broker:29092
docker-compose exec broker /opt/kafka/bin/kafka-topics.sh -create --topic baseball-scores --bootstrap-server broker:29092