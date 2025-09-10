namespace API.DTOs;

public class CreateMessageDto
{
    public required string RecipientId { get; set; }
    public required string Content { get; set; }

    public CreateMessageDto() { }

    public CreateMessageDto(string recipientId, string content)
    {
        RecipientId = recipientId;
        Content = content;
    }
}
