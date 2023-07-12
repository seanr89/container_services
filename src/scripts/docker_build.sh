#!/bin/sh

set -e -u #Exit immediately if a command exits with a non-zero status.

echo "Executing script!"

cd ../services/boulders/boulder.api
docker build . -f Dockerfile -t 'boulderapi:latest'

cd ../../

cd ../services/webhooks/webhooks.api
docker build . -f Dockerfile -t 'webhooks:latest'

cd ../../

cd ../services/healthchecker.api/
##docker build . -f Dockerfile -t 'healthchecker:latest'

echo "Dockerisation Complete!"
