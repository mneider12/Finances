Record ID Manager

**Purpose**
Object that handles saving and loading the list of IDs used by Record Factory to assigned unique IDs to records

Contains a serializable dictionary from record types to next available ID

Approach:

At first, I will create a Record ID Manager that doesn't persist that can provide test data
MockRecordIdManager

Considered but not done:
Use a factory pattern to create Record ID Managers
- only ever going to need / want 1 Record ID manager