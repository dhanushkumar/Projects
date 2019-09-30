/**
 * The RollupProductCodeListOnOpps trigger rolls up the Product Codes into a concatenated list on the parent Opportunity
 * 
 * Tech CXO
 * June 25, 2018
 */
trigger RollupProductCodeListOnOpps on OpportunityLineItem (before insert, before delete, before update, after undelete) {
    map<Id,Opportunity> oppsForUpdate = new map<Id,Opportunity>();
    list<Id> oppIds = new list<Id>();
    
    if(Trigger.isInsert || Trigger.isUndelete || Trigger.isupdate) {      
        // Get all Opportunity Ids
        for(OpportunityLineItem oli : Trigger.new) {
            oppIds.add(oli.OpportunityID);
        }
        
        oppsForUpdate = new map<Id,Opportunity>([SELECT Id, Product_List__c , Name 
                                                 FROM Opportunity 
                                                 WHERE Id IN :oppIds]);
        if(!oppsForUpdate.isEmpty()) {
            for(OpportunityLineItem oli : Trigger.new) {
                Opportunity oppty = oppsForUpdate.get(oli.OpportunityId);
                if(oppty.Product_List__c  == null || oppty.Product_List__c  == '') { 
                    // If empty then simply add
                    oppty.Product_List__c  = oli.Product_Code_Calc__c;
                }
                else if(!string.valueOf(oppty.Product_List__c ).contains(string.valueOf(oli.Product_Code_Calc__c))) {
                    // If code doesn't exist in the list
                    oppty.Product_List__c  += ', ' + oli.Product_Code_Calc__c;
                }

                // Override map entry for next cycle
                oppsForUpdate.put(oli.OpportunityId,oppty);
            }
            update oppsForUpdate.values();
        }
        
    } 
    else if(Trigger.isDelete) {        
        // Get all Opportunity Ids
        for(OpportunityLineItem oli : Trigger.old) {
            oppIds.add(oli.OpportunityID);
        }
        
        // Check other OLIs for the oppty and then either remove product code or if other OLI has same product then ignore
        map<Id,OpportunityLineItem> allOLItems = new map<Id,OpportunityLineItem>();
        allOLItems = new map<Id,OpportunityLineItem>([SELECT Id,OpportunityId,Product_Code_Calc__c 
                                                      FROM OpportunityLineItem
                                                      WHERE OpportunityId IN :oppIds AND
                                                            Id NOT IN: Trigger.oldMap.keyset()]);
        oppsForUpdate = new map<Id,Opportunity>([SELECT Id, Product_List__c, Name 
                                                 FROM Opportunity 
                                                 WHERE Id IN :oppIds]);
        if(!oppsForUpdate.isEmpty()) {
            for(Opportunity Opp: oppsForUpdate.values()) {
                // Set it to null and then can be used to recalcualte
                Opp.Product_List__c = null;
                oppsForUpdate.put(Opp.Id,Opp);
            }

            for(OpportunityLineItem oli : allOLItems.values()) {
                Opportunity oppty = oppsForUpdate.get(oli.OpportunityId);
                if(oppty.Product_List__c  == null || oppty.Product_List__c  == ''){
                    // If empty then simply add
                    oppty.Product_List__c  = oli.Product_Code_Calc__c;
                }
                else if(!string.valueOf(oppty.Product_List__c ).contains(string.valueOf(oli.Product_Code_Calc__c))) {
                    // If code doesn't exist in the list
                    oppty.Product_List__c  += ', ' + oli.Product_Code_Calc__c;
                }
                
                // Override map entry for next cycle
                oppsForUpdate.put(oli.OpportunityId,oppty);
            }
            update oppsForUpdate.values();
        }    
    }
}