// See https://aka.ms/new-console-template for more information
using Azure.AI.OpenAI;

Console.WriteLine("Avstract Interpolation");

OpenAIClient client1 = new OpenAIClient("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");

OpenAIClient client2 = new OpenAIClient("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");

string question = @"Can you write a linear interpolation for inputs Dictionary<int, double> with a list of interp x points List<int> that passes back a Dictionary<int, double>, please include examples";

//string question = @"If I wanted to create a class thet would take 2 types of inputs Dictionary<int, double> or Dictionary<(int, int), double>, and output either Dictionary<int, double> or Dictionary<(int, int), double> how would I do this";
var completions = new ChatCompletionsOptions()
{
    Messages = { new ChatMessage(ChatRole.System, question) }
};

var openAiResponse35 = await client1.GetChatCompletionsAsync("gpt-3.5-turbo", completions);

var openAiResponse4 = await client2.GetChatCompletionsAsync("gpt-4", completions);

List<string> results = new List<string>();


results.Add("");
results.Add("## Chat GPT 3.5");
results.Add("");
foreach (var item in openAiResponse35.Value.Choices)
{
    results.Add(item.Message.Content);    
}


results.Add("");
results.Add("## Chat GPT 4.0");
results.Add("");
foreach (var item in openAiResponse4.Value.Choices)
{
    results.Add(item.Message.Content);
}

question = @"Can you provide unit tests using xunit please for the interpolator you previously gave me, and some performance tests for testing with large numbers of inputs";

//string question = @"If I wanted to create a class thet would take 2 types of inputs Dictionary<int, double> or Dictionary<(int, int), double>, and output either Dictionary<int, double> or Dictionary<(int, int), double> how would I do this";
completions = new ChatCompletionsOptions()
{
    Messages = { new ChatMessage(ChatRole.System, question) }
};

openAiResponse35 = await client1.GetChatCompletionsAsync("gpt-3.5-turbo", completions);

openAiResponse4 = await client2.GetChatCompletionsAsync("gpt-4", completions);


results.Add("");
results.Add("## Chat GPT 3.5");
results.Add("");
foreach (var item in openAiResponse35.Value.Choices)
{
    results.Add(item.Message.Content);
}


results.Add("");
results.Add("## Chat GPT 4.0");
results.Add("");
foreach (var item in openAiResponse4.Value.Choices)
{
    results.Add(item.Message.Content);
}

File.WriteAllLines(@"C:\scratch\Abstract.md", results);


int x = 0;