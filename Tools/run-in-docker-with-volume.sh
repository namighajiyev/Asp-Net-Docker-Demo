docker build -t asp-net-docker-demo-app .
docker volume create asp-net-docker-demo-app-vol
docker run -it --rm -p 8080:80 \
--mount type=volume,source=asp-net-docker-demo-app-vol,target=/app/logs/asp-net-docker \
--name asp-net-docker-demo-app asp-net-docker-demo-app