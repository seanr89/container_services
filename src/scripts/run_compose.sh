#!/bin/sh

set -e -u #Exit immediately if a command exits with a non-zero status.

echo "Executing Docker Compose"

cd ../services/

ls

docker compose up

echo "Docker Compose Run Complete!"