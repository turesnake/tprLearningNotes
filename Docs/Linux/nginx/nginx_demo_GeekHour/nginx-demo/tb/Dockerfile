FROM golang:1.20 as builder
MAINTAINER "Jasper Yang"
ENV APP_HOME /app
COPY main.go ./
RUN go build -a -o tb main.go

FROM alpine:latest
WORKDIR $APP_HOME
COPY $APP_HOME/tb ./
EXPOSE 8002
CMD $APP_HOME/tb



