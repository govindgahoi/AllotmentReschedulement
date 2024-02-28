using System;

public class DynamicHeader
{
    public int HeaderDepth { get; set; }
    public String[] Headers { get; set; }
	public DynamicHeader(String header)
	{
        Headers = header.Split('|');
        HeaderDepth = Headers.Length;
	}
}
