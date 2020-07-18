1. Identify an image that's being manually created
1. Delete old .SVG and old approve.dot file
1. Find the corresponding test that created the GraphViz .dot file that was used to create the image
1. Change the test to generate the .svg
1. Change the documentation to use the generated file
1. Build
1. Commit



100. Look for stray approved files
    - delete all approved files
    - enable clipboard reporter
    - run all tests
    - paste-and-run