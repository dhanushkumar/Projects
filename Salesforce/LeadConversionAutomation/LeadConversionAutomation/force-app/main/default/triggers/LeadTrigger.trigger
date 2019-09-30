trigger LeadTrigger on Lead (after insert, after update) {
    List<Lead> convertibleLeads = new List<Lead>();
	if(Trigger.isAfter && Trigger.isInsert)
    {
        LeadTriggerHandler.ConvertLeads(Trigger.New);
    }
    if(Trigger.isAfter && Trigger.isUpdate)
    {
        LeadTriggerHandler.ConvertLeads(Trigger.New);
    }
}