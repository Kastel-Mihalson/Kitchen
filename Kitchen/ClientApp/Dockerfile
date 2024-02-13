FROM node:16.16.0 as build
WORKDIR /usr/src/app
COPY ./Kitchen/ClientApp/package.json ./Kitchen/ClientApp/package-lock.json ./
RUN npm install
COPY ./Kitchen/ClientApp/ .
RUN npm run build

FROM nginx:stable-alpine3.17-slim
COPY ./Kitchen/ClientApp/nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/src/app/dist/kitchen /usr/share/nginx/html

CMD ["/bin/sh",  "-c",  "exec nginx -g 'daemon off;'"]
