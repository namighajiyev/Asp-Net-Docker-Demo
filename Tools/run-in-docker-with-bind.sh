docker build -t asp-net-docker-demo-app .
mkdir -p  /logs/asp-net-docker
docker run -it --rm -p 8080:80 \
--mount type=bind,source=/logs/asp-net-docker,target=/app/logs/asp-net-docker \
--name asp-net-docker-demo-app asp-net-docker-demo-app