<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:st="urn:students">
<xsl:template match="/">
  <html lang="en">
  <head>
    <meta charset="utf-8"/>
    <style>
      body {
        background-color: teal;
      }
      
      td, th {
        text-align: center;
        vertical-align: center;
      }
    </style>
  </head>
  <body>
    <h1>Students</h1>
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Course</th>
          <th>Speciality</th>
          <th>Phone</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
      <xsl:for-each select="st:students/st:student">
        <tr>
          <td><xsl:value-of select="st:name"/></td>
          <td><xsl:value-of select="st:course"/></td>
          <td><xsl:value-of select="st:speciality"/></td>
          <td><xsl:value-of select="st:phone"/></td>
          <td><xsl:value-of select="st:email"/></td>
        </tr>
    </xsl:for-each>
    </tbody>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>
