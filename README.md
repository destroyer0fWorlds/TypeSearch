# TypeSearch

### tl;dr
A strongly typed but serializable search mechanism written in .Net Standard. Create a query, send it to an API, get the results, have a beer.

### Documentation
[GitHub Wiki](https://github.com/destroyer0fWorlds/TypeSearch/wiki)

### Nuget
Browse: [https://www.nuget.org/packages/TypeSearch/](https://www.nuget.org/packages/TypeSearch/)
or
Download: ``` PM> Install-Package TypeSearch -Version 1.0.2 ```

### License
[MIT](https://opensource.org/licenses/MIT) - happy coding!

### Background:
Some time ago, I worked for a company with their own serializable search mechanism. It was clever, in that, it let API consumers build complex and dynamic queries which could be run server-side against a database; you build a query, send in your request, and the API would serve up the results. You could specify page, sort, and filter. It was powerful. It had one major flaw though, it was awkward as hell to use. This was due in large part to the fact that it carried no type information whatsoever. You had to constantly request schema information via separate API calls and tell the search mechanism which table and columns you wanted. I figured that with the advent of generics, there wasn't any reason for this so I set about creating a strongly typed search. This is it (more or less). It has undergone some changes over time but the idea remains the same: create a strongly typed search which can be serialized and sent across the web.

I created this for me. I have no illusions that anyone else will ever find this or want to use it. I made a nuget package so I could download it easily in other projects - figured since I made a public nuget package, I should make a public repo too.
