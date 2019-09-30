/*
 * The TestRollupProductCodeListOnOpps tests that the product codes on the OLIs are properly rolled
 * up into a list on the Opportunity
 * 
 * Tech CXO
 * June 25, 2018
 */
@isTest
public class TestRollupProductCodeListOnOpps {    
    /*
    * The rollupProductCodeListOnOpps tests to see if the Opportunity Line Item product codes were
    * rolled up onto the Opportunity in the Product_List__c field
    */
    static testMethod void rollupProductCodeListOnOpps() {     
		// Create a test Account and primary Contact
        Account account = new Account();
        account.Name = 'Test Account';
        account.BillingStreet = '123 Main Street';
        account.BillingCity = 'Atlanta';
        account.BillingState = 'GA';
        account.BillingCountry = 'Canada';
        account.BillingPostalCode = '12345';
        insert account;
        
		Contact primaryContact = new Contact();
		primaryContact.LastName = 'Testy';
        insert primaryContact;
        
        // Create a test Opportunity
        Opportunity newOpportunity = new Opportunity();
        newOpportunity.Name = 'Test Opportunity';
        newOpportunity.StageName = 'S1: Pre-Qualified';
        newOpportunity.CloseDate = Date.today().addDays(30);        
        newOpportunity.AccountId = account.Id;
        insert newOpportunity;
        
        // Create a test Opportunity Contact Role
        OpportunityContactRole opportunityContactRole = new OpportunityContactRole();
        opportunityContactRole.ContactId = primaryContact.Id;
        opportunityContactRole.OpportunityId = newOpportunity.Id;
        opportunityContactRole.Role = 'Decision Maker';
		opportunityContactRole.IsPrimary = true;        
        insert opportunityContactRole;
                        
        // Create some Opportunity Line Items
        Id pricebookId = Test.getStandardPricebookId();

        Product2 product1 = new Product2();
        product1.Name = 'ProductName1';
        product1.ProductCode = 'ProductCode1';
        product1.isActive = true;
        insert product1;
        
        PricebookEntry pricebookEntry1 = new PricebookEntry();
        pricebookEntry1.Pricebook2Id = pricebookId;
        pricebookEntry1.Product2Id = product1.Id;
        pricebookEntry1.UnitPrice = 3.14;
        pricebookEntry1.IsActive = true;
        insert pricebookEntry1;
        
        OpportunityLineItem oli1 = new OpportunityLineItem();
		oli1.PricebookEntryId  = pricebookEntry1.Id;
        oli1.Quantity = 1;
        oli1.Description = 'This is number 1';
        oli1.OpportunityId = newOpportunity.Id;
        oli1.TotalPrice = oli1.Quantity * pricebookEntry1.UnitPrice;
        
        Product2 product2 = new Product2();
        product2.Name = 'ProductName2';
        product2.ProductCode = 'ProductCode2';
        product2.isActive = true;
        insert product2;
        
        PricebookEntry pricebookEntry2 = new PricebookEntry();
        pricebookEntry2.Pricebook2Id = pricebookId;
        pricebookEntry2.Product2Id = product2.Id;
        pricebookEntry2.UnitPrice = 42.00;
        pricebookEntry2.IsActive = true;
        insert pricebookEntry2;
        
        OpportunityLineItem oli2a = new OpportunityLineItem();
        oli2a.PricebookEntryId  = pricebookEntry2.Id;
        oli2a.Quantity = 2;
        oli2a.Description = 'This is number 2';
        oli2a.OpportunityId = newOpportunity.Id;
        oli2a.TotalPrice = oli2a.Quantity * pricebookEntry2.UnitPrice;
        
        OpportunityLineItem oli2b = new OpportunityLineItem();
        oli2b.PricebookEntryId  = pricebookEntry2.Id;
        oli2b.Quantity = 5;
        oli2b.Description = 'This is number 2 again';
        oli2b.OpportunityId = newOpportunity.Id;
        oli2b.TotalPrice = oli2b.Quantity * pricebookEntry2.UnitPrice;
        
        Account newAccount = [SELECT Id
                              FROM Account
                              WHERE Id = :newOpportunity.AccountId];
        
        // Run the test
        test.startTest();
        
        // Insert the first OLI
        insert oli1;               
        Opportunity theOpportunity = [SELECT Id, Product_List__c
                                      FROM Opportunity
                                      WHERE Id = :newOpportunity.Id];        
        System.assertEquals(theOpportunity.Product_List__c, 'ProductCode1');
        
        // Insert the second OLI
        insert oli2a;
        theOpportunity = [SELECT Id, Product_List__c
                          FROM Opportunity
                          WHERE Id = :newOpportunity.Id];        
        System.assertEquals(theOpportunity.Product_List__c, 'ProductCode1, ProductCode2');

		// Delete the first OLI
        delete oli1;
        theOpportunity = [SELECT Id, Product_List__c
                          FROM Opportunity
                          WHERE Id = :newOpportunity.Id];        
        System.assertEquals(theOpportunity.Product_List__c, 'ProductCode2');
        
        // Insert an OLI with the same code as oli2; the product code should not be duplicated
        insert oli2b;
        theOpportunity = [SELECT Id, Product_List__c
                          FROM Opportunity
                          WHERE Id = :newOpportunity.Id];        
        System.assertEquals(theOpportunity.Product_List__c, 'ProductCode2');
        
        test.stopTest();
    } 
}