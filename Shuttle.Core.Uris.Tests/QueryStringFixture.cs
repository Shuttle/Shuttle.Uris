using NUnit.Framework;

namespace Shuttle.Core.Uris.Tests;

[TestFixture]
public class QueryStringFixture
{
    [Test]
    public void Should_not_be_able_to_add_duplicate_keys()
    {
        var qs = new QueryString { { "key", "value" } };

        Assert.Throws<ArgumentException>(() => qs.Add("key", "value"));
    }

    [Test]
    public void Should_be_able_to_get_from_uri()
    {
        var uri = new Uri("the-scheme://the-host?key1=value1&key2=value2");

        var qs = new QueryString(uri);

        Assert.That(qs.Count, Is.EqualTo(2));
        Assert.That(qs["key1"], Is.EqualTo("value1"));
        Assert.That(qs["key2"], Is.EqualTo("value2"));
    }

    [Test]
    public void Should_be_able_to_handle_an_empty_query_string()
    {
        var uri = new Uri("the-scheme://the-host");

        var qs = new QueryString(uri);

        Assert.That(qs.Count, Is.EqualTo(0));
    }

    [Test]
    public void Should_return_an_empty_string_when_key_not_found()
    {
        var uri = new Uri("the-scheme://the-host");

        var qs = new QueryString(uri);

        Assert.That(qs["not-here"], Is.Null);
    }
}