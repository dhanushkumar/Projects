global class LeadConversionHandler implements Database.Batchable<sObject>{
    List<Lead> convertibleLeads = new List<Lead>();
    global LeadConversionHandler(List<Lead> leads)
    {
        convertibleLeads = getConvertibleLeads(leads);
    }
    global void ConvertLeads()
    {
        List<Database.LeadConvert> leadConverts = getLeadConverts(convertibleLeads);
        List<Database.LeadConvertResult> results = Database.convertLead(leadConverts,false);
    }
    global List<Lead> start(Database.BatchableContext context)
    {     
        return convertibleLeads;
    }
     global void execute(Database.BatchableContext context, List<Lead> leads)
    {        
       	convertibleLeads = leads;
       	ConvertLeads();
    }
    global void Finish(Database.BatchableContext contect){  }
    private static List<Database.LeadConvert> getLeadConverts(List<Lead> leads)
    {
        List<Database.LeadConvert> leadConverts = new List<Database.LeadConvert>();
        for(Lead lead: leads)
        {
          	Database.LeadConvert leadConvert = new database.LeadConvert();
            leadConvert.setLeadId(lead.id);
            leadConvert.ConvertedStatus = 'Closed - Converted';   //find what converted status should be
            leadConverts.Add(leadConvert);
        }
        return leadConverts;
    }
    private static List<Lead> getConvertibleLeads(List<Lead> leads)
    {
        List<Lead> convertibleLeads = new List<Lead>();
        for (Lead lead: leads)
        {
            if(!lead.IsConverted  && lead.Self_Converted__c)
        	{
             convertibleLeads.add(lead);
        	}
        }
        return convertibleLeads; //yes
    }

}