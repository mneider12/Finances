ID Assignment

Considerations:
Important to be strictly moduralized in order to allow for expanding to multiple connections to the database

Behaviors:
It's OK if we reserve IDs and then don't save them
deleted records may leave gaps in used IDs
No two records of the same type may share an ID

Technical Design:
Keep a master list of IDs by type
All record factories should inherit from a shared RecordFactory abstract class that handles sequential ID generation

Considered but not done:
Allowing for non-sequental IDs (manually selected, or using an external ID), because none of the currently conceived records would have meaningful IDs, and external Ids can be added later.
- If it becomes necessary it should suffice to inherit a non-sequental class that still inherits from the master class
