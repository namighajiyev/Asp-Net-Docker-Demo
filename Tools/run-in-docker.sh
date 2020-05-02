docker build -t asp-net-docker-app .
docker run -it --rm -p 8080:80 asp-net-docker-app