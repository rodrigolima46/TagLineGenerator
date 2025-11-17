using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Chat;
using dotenv.net;

class Program
{
    static async Task Main()
    {

        DotEnv.Load();
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("OPENAI_API_KEY not found. Set it in your environment or .env.");
            return;
        } 

        var client = new OpenAIClient(apiKey);

        // Use ChatClient from OpenAI.Chat namespace
        var chat = client.GetChatClient("gpt-3.5-turbo");

        string userMessage = "I need a tagline for my petstation";

       // Complete the chat based on the single message
        ChatCompletion completion = await chat.CompleteChatAsync(userMessage);

        // Print the assistant’s reply
        Console.WriteLine(completion.Content[0].Text);

    }
}
