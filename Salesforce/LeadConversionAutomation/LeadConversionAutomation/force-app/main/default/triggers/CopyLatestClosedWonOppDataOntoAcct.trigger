/*
 * The CopyLatestClosedWonOppInfoOntoAcct trigger updates the parent account of the triger Opportunities
 * with some data points from the account opportunity with the most recently Closed/Won opportunity that
 * has one of the following data points:
 *     * Marketing Pain Points
 *     * Plan Start Date
 *     * Plan Renewal Date
 *      
 * If there aren't any (Closed/Won) opportunities, we'll need to unset the data points that had 
 *
 * Tech CXO
 * June 30, 2018
 */
trigger CopyLatestClosedWonOppDataOntoAcct on Opportunity (after insert, after update, after delete) {
    // Based on the type of CRUD, get the correct trigger list
    List<Opportunity> triggerOpps = null;
    if(trigger.isInsert || trigger.isUpdate) {
        triggerOpps = trigger.new;
    }
    else {
        triggerOpps = trigger.old;
    }
    
    // Build a set of parent accounts that might need updating
    Set<account> parentAccounts = new Set<account>();
    for(Opportunity opp : triggerOpps) {
        Account account = [SELECT Id, CreatedDate, Name
                           FROM Account
                           WHERE Id = :opp.AccountId];
        parentAccounts.add(account);
    }
        
    // Loop through each of the parent acccounts
    for(Account account : parentAccounts) {
        // Look up the opportunities on the account        
        List<Opportunity> opps = [SELECT Id, CloseDate, StageName, Marketing_Pain_Points__c,
                                         Plan_Start_Date__c, Plan_Renewal_Date__c, Name,
                                         IsClosed, IsWon
                                  FROM Opportunity
                                  WHERE AccountId = :account.Id];
        
        if (!opps.isEmpty()) {
            // If there are opportunities, check to see which are Closed/Won and find the latest one
            // that is Closed/Won AND has one or more of the data points in question
            Datetime latestCloseDate = null;
            Opportunity latestClosedWonOppWithData = null;
            
            for(Opportunity opp : opps) {
                if(opp.IsClosed && opp.IsWon) {
                    // If there is not previously found close date, or this one is later than a previously
                    // found close date AND there is some data, mark this opportunity as the current latest
                    if((latestCloseDate == null || opp.CloseDate >= latestCloseDate) && 
                       (opp.Marketing_Pain_Points__c != null || opp.Plan_Start_Date__c != null || 
                         opp.Plan_Renewal_Date__c != null)) {
                        latestCloseDate = opp.CloseDate;
                        latestClosedWonOppWithData = opp;
                    }                    
                }               
            }
            
            // If we have a Closed/Won opportunity, update the parent account
            if(latestClosedWonOppWithData != null) {
                // Roll up the opportunity data points onto the account
                account.Marketing_Pain_Points__c = latestClosedWonOppWithData.Marketing_Pain_Points__c;
                account.Subscription_Start_Date__c = latestClosedWonOppWithData.Plan_Start_Date__c;
                account.Subscription_End_Date__c = latestClosedWonOppWithData.Plan_Renewal_Date__c;
                update account;             
            }
            else {
                // If there aren't any latest Closed/Won dates, an opportunity might have been reopened
                // so we'll need to unset any previously set opportunity data points.
                account.Marketing_Pain_Points__c = null;
                account.Subscription_Start_Date__c = null;
                account.Subscription_End_Date__c = null;
                update account;
            }
        }
        else {
            // If there aren't any opportunities with this account then we are in a deleted scenario.
            // We'll need to unset any previously set opportunity data points.
            account.Marketing_Pain_Points__c = null;
            account.Subscription_Start_Date__c = null;
            account.Subscription_End_Date__c = null;
            update account;
        }
    }
}