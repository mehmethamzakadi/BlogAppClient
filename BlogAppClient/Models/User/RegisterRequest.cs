﻿
namespace BlogAppClient.Models.User;

public sealed record RegisterRequest(string UserName, string Email, string Password);
