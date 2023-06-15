
using Google.Cloud.Datastore.V1;

// Your Google Cloud Platform project ID
string projectId = "focus-cache-387205";

// Instantiates a client
DatastoreDb db = DatastoreDb.Create(projectId);

// The kind for the new entity
string kind = "Task";
// The name/ID for the new entity
string name = "sampletask1";
KeyFactory keyFactory = db.CreateKeyFactory(kind);
// The Cloud Datastore key for the new entity
Key key = keyFactory.CreateKey(name);

var task = new Entity
{
    Key = key,
    ["description"] = "Buy milk"
};
using (DatastoreTransaction transaction = db.BeginTransaction())
{
    // Saves the task
    transaction.Upsert(task);
    transaction.Commit();

    Console.WriteLine($"Saved {task.Key.Path[0].Name}: {(string)task["description"]}");
}