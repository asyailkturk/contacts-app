ù
hC:\Users\Asya\source\repos\contacts-app\src\BuildingBlocks\EventBus.Messages\Common\EventBusConstants.cs
	namespace 	
EventBus
 
. 
Messages 
. 
Common "
{ 
public 

static 
class 
EventBusConstants )
{ 
public 
const 
string 
ReportCreateQueue -
=. /
$str0 D
;D E
} 
} …
kC:\Users\Asya\source\repos\contacts-app\src\BuildingBlocks\EventBus.Messages\Events\IntegrationBaseEvent.cs
	namespace 	
EventBus
 
. 
Messages 
. 
Events "
{ 
public 

class  
IntegrationBaseEvent %
{ 
public  
IntegrationBaseEvent #
(# $
)$ %
{ 	
Id 
= 
Guid 
. 
NewGuid 
( 
) 
;  
CreationDate 
= 
DateTime #
.# $
UtcNow$ *
;* +
}		 	
public  
IntegrationBaseEvent #
(# $
Guid$ (
id) +
,+ ,
DateTime- 5

createDate6 @
)@ A
{ 	
Id 
= 
id 
; 
CreationDate 
= 

createDate %
;% &
} 	
public 
Guid 
Id 
{ 
get 
; 
private %
set& )
;) *
}+ ,
public 
DateTime 
CreationDate $
{% &
get' *
;* +
private, 3
set4 7
;7 8
}9 :
} 
} 