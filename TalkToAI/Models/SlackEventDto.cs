namespace TalkToAI.Models;

public class Authorization
{
    public object enterprise_id { get; set; }
    public string team_id { get; set; }
    public string user_id { get; set; }
    public bool is_bot { get; set; }
    public bool is_enterprise_install { get; set; }
}

public class Block
{
    public string type { get; set; }
    public string block_id { get; set; }
    public List<Element> elements { get; set; }
}

public class Element
{
    public string type { get; set; }
    public List<Element> elements { get; set; }
    public string text { get; set; }
}

public class Event
{
    public string client_msg_id { get; set; }
    public string type { get; set; }
    public string text { get; set; }
    public string user { get; set; }
    public string ts { get; set; }
    public List<dynamic> blocks { get; set; }
    public string team { get; set; }
    public string channel { get; set; }
    public string event_ts { get; set; }
    public string channel_type { get; set; }
}

public class SlackEventDto
{
    public string token { get; set; }
    public string team_id { get; set; }
    public string context_team_id { get; set; }
    public object context_enterprise_id { get; set; }
    public string api_app_id { get; set; }
    public Event @event { get; set; }
    public string type { get; set; }
    public string event_id { get; set; }
    public int event_time { get; set; }
    public List<Authorization> authorizations { get; set; }
    public bool is_ext_shared_channel { get; set; }
    public string event_context { get; set; }
}
