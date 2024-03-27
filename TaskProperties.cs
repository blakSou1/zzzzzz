using System;

public class TaskProperties
{
	private string? _nameTask;
	private string? _content;

	public TaskProperties(string? name, string? content)
	{
		_nameTask = name;
		_content = content;
	}

	public void newContent(string? name, string? content)
	{
		_nameTask = name;
		_content = content;
	}

	public string? accessNameTask()
	{
		return _nameTask;
	}
	public string? accessContentTask()
	{
		return _content;
	}
}
