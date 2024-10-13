package main

import (
	"fmt"
	"log"
	"net/http"
)

func sayhelloName(response http.ResponseWriter, request *http.Request) {
	request.ParseForm()
	fmt.Println(request.Form)
	fmt.Fprintf(response, "<h1>8000端口!</h1>")
}

func main() {
	fmt.Println("================= Server Started ================= ")
	http.HandleFunc("/", sayhelloName)
	err := http.ListenAndServe(":8000", nil)
	if err != nil {
		log.Fatal("ListenAndServe: ", err)
	}
	fmt.Println("================= Server Stopped ================= ")
}
