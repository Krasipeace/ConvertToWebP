using Libwebp.Net;
using Libwebp.Standard;

// get file to encode
using var file = new FileStream(@"C:\Users\Krasimir\Desktop\test\test.jpg", FileMode.Open);

// copy file to Memory
using var ms = new MemoryStream();
await file.CopyToAsync(ms);

//setup configuration for the encoder
var config = new WebpConfigurationBuilder()
                .Output("C:\\Users\\Krasimir\\Desktop\\test\\output.webp")
                .Build();

// create an encoder and pass in the configuration
var encoder = new WebpEncoder(config);

// start encoding by passing your memorystream and filename      
var output = await encoder.EncodeAsync(ms, Path.GetFileName(file.Name));

/* your converted file is returned as FileStream, do what you want download,
   copy to disk, write to db or save on cloud storage,*/

Console.WriteLine($"Your output file : {Path.GetFileName(output.Name)}");
Console.WriteLine($"Length in bytes : {output.Length}");