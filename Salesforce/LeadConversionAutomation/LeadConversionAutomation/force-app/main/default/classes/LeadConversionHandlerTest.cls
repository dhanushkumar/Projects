@isTest
public class LeadConversionHandlerTest {
	
    @testSetup public static void LeadDataSetUp()
    {
        List<Lead> leads = new List<Lead>();
         for(Integer i=0;i<10;i++) {
            leads.add(new Lead(
            LastName = i + 'Unit Test', 
            Company = i + 'Test Company', 
            self_converted__c = true, 
            Matcha_App_Client_Name__c = i + 'Matcha App Test Client'
            ));}        
       // Required to test BatchApex class
        Test.startTest();
        insert leads;
        Test.stopTest();
    }
    
    @isTest public static void AccountCreationTest()
    {
        Lead insertedLead  = [SELECT ConvertedAccountId from Lead where Company='0Test Company'];
        Account acc = [Select Id from Account where Id= :insertedLead.ConvertedAccountId];
        System.assertEquals(insertedLead.ConvertedAccountId, acc.Id);
    }
   
    /*Make sure that the number of records inserted is less than the batch size of 200 
    because test methods can execute only one batch total.
    Test only 10 for now as a batch handles less insertions while many process builder actions occur. 
    This test requires revisiting as more updates to process builder are made*/
     @isTest public static void BulkLeadConversionTest()
    {
        List<Account> convertedAccounts  = [SELECT Id from Account where Name like '%Matcha App Test Client'];
        System.assertEquals(10, convertedAccounts.size());
    }
    @isTest public static void ContactCreationTest()
    {
        Lead insertedLead  = [SELECT ConvertedContactId from Lead where Company='0Test Company'];
        Contact contact = [Select Id from Contact where Id= :insertedLead.ConvertedContactId];
        System.assertEquals(insertedLead.ConvertedContactId, contact.Id);
    }
    
    //Account name update via processbuilder test. Should fail if not set up correctly
    @isTest public static void AccountNameUpdateInProcessBuilderTest()
    {
        Lead insertedLead  = [SELECT ConvertedAccountId from Lead where Company='0Test Company'];
        Account acc = [Select Name from Account where Id= :insertedLead.ConvertedAccountId ];
        //following will fail if 'Update To Matcha Client Account Name' process is not set up correctly.
        System.assertEquals('0Matcha App Test Client', acc.Name);
    }
    
    //Opportunity stage update in process builder test. This should fail if the process builder is not set up correctly
    //Not working while batch conversion. Need to find out why
     @isTest public static void TransitionToClosedWonInProcessBuilderTest()
    {
        Lead insertedLead  = [SELECT ConvertedOpportunityId from Lead where Company='0Test Company'];
        Opportunity opportunity = [Select StageName from Opportunity where Id= :insertedLead.ConvertedOpportunityId];
        //following will fail if 'Update Oppotunity to Close-Won' process is not set up correctly.
        System.assertEquals('S4: Closed Won', opportunity.StageName);
    }
}