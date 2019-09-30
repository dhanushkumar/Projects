public class LeadTriggerHandler {
    //We need to handle large load of leads in batches, else process builder actions may fail
    public static void ConvertLeads(List<Lead> leads)
    {
        LeadConversionHandler conversionHandler = new LeadConversionHandler(leads);
        if(leads.size()> 5)
        {
           Database.executeBatch(conversionHandler);
        }
        else
        {
            conversionHandler.convertLeads();
        }
    }
}