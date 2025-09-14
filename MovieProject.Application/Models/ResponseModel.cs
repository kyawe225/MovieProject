using System;

namespace MovieProject.Application.Models;

public class ResponseModel<T>
{
    public string Status { set; get; }
    public string Message { set; get; }
    public T data { set; get; }
}

