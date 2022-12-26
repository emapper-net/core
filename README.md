# EMapper.net

EMapper.net is a .NET library for generating object mapping code at compile time. It is designed to help developers overcome performance issues associated with using reflection-based approaches to object mapping, such as those used by libraries like AutoMapper, without the added effort needed to manually write mapping code.

With emapper.net, you can specify the object mappings you want to use in your application, and the library will generate the corresponding mapping code for you at compile time. This can provide several benefits, including:

- Improved performance (compared to manual mapping or reflection-based approaches, as demonstrated in [this article](https://www.codeproject.com/Articles/1160497/Manual-Mapping-vs-Automapper-A-Performance-Comparis) and [this blog post](https://www.troyhunt.com/comparing-automapper-to-hand-written-mapping/))
- Better type safety
- Greater control over the generated code
- Simplified maintenance

In addition to generating object mapping code, emapper.net also provides various customization options to allow you to fine-tune the generated code to meet your specific needs. If you're not sure whether emapper.net is the right choice for your project, you may also want to consider the pros and cons of [manual mapping versus AutoMapper](https://stackoverflow.com/questions/647778/automapper-vs-hand-coded-mapping) and other reflection-based approaches.
